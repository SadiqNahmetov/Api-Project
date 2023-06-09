﻿using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.Student;
using ServiceLayer.Helpers;
using ServiceLayer.Services.Interfaces;

namespace ServiceLayer.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository,
            ICourseRepository courseRepository,
            IMapper mapper)

        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }


        public async Task<StudentDto> GetAsync(int id)
        {
            return _mapper.Map<StudentDto>(await _studentRepository.GetWithCoursesAsync(id));
        }


        public async Task<List<StudentListDto>> GetAllAsync()
        {
            return _mapper.Map<List<StudentListDto>>(await _studentRepository.GetAllWithCoursesAsync());
        }


        public async Task CreateAsync(StudentCreateDto studentCreateDto)
        {
            var course = await _courseRepository.GetAsync(studentCreateDto.CourseId);

            var mapStudent = _mapper.Map<Student>(studentCreateDto);

            mapStudent.Image = await studentCreateDto.Photo.GetBytes();

            mapStudent.Course = course;

            await _studentRepository.CreateAsync(mapStudent);
        }


        public async Task UpdateAsync(int id, StudentUpdateDto studentUpdateDto)
        {
            var dbStudent = await _studentRepository.GetWithCoursesAsync(id);

            dbStudent.Id = id;
            dbStudent.CourseId = studentUpdateDto.CourseId;

            var mapStudent = _mapper.Map(studentUpdateDto, dbStudent);

            mapStudent.Image = await studentUpdateDto.Photo.GetBytes();

            await _studentRepository.UpdateAsync(mapStudent);
        }


        public async Task DeleteAsync(int id)
        {
            await _studentRepository.DeleteAsync(await _studentRepository.GetAsync(id));
        }


        public async Task SoftDeleteAsync(int id)
        {
            await _studentRepository.SoftDelete(await _studentRepository.GetAsync(id));
        }
    }
}