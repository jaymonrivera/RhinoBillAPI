using MediatR;
using Moq;
using RhinoBill.CRUD.Common.Command;
using RhinoBill.CRUD.Controllers.Students.Dtos;
using RhinoBill.CRUD.MediatRCommon.Commands;
using RhinoBill.CRUD.Models;
using RhinoBill.CRUD.Services;
using RhinoBill.CRUD.Services.Interfaces;
using Shouldly;
namespace RhinoBill.Tests.Services;

[TestFixture]
public class StudentServiceTests
{
    private Mock<IMediator> _mediatorMock;
    private IStudentService _studentService;
    private StudentFormValidator _validator;

    [SetUp]
    public void Setup()
    {
        _mediatorMock = new Mock<IMediator>();
        _studentService = new StudentService(_mediatorMock.Object);
        _validator = new StudentFormValidator();
    }

    [Test]
    public async Task GetStudentsAsync_ShouldReturn_ListOfStudents()
    {
        // Arrange
        var studentsList = new List<StudentListDto>
        {
            new StudentListDto {
                Id = 1,
                FirstName = "Jaymon",
                LastName = "Rivera",
                DateOfBirth = new DateTime(1996, 07, 18),
                Email = "jaymon@test.com",
                PhoneNumber = "09759623147"
            }
        };

        _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllCommand<Student, StudentListDto>>(), default))
                .ReturnsAsync(studentsList);

        // Act
        var result = await _studentService.GetStudentsAsync();

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<List<StudentListDto>>();
        result.Count().ShouldBe(1);
        result[0].FirstName.ShouldBe("Jaymon");
    }

    [Test]
    public async Task GetStudentByIdAsync_ShouldReturn_Student()
    {
        // Arrange
        var student = new StudentFormDto
        {
            FirstName = "Jaymon",
            LastName = "Rivera",
            DateOfBirth = new DateTime(1996, 07, 18),
            Email = "jaymon@test.com",
            PhoneNumber = "09759623147"
        };

        _mediatorMock.Setup(m => m.Send(It.IsAny<GetByIdCommand<Student, StudentFormDto>>(), default))
                     .ReturnsAsync(student);

        // Act
        var result = await _studentService.GetStudentByIdAsync(1);

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<StudentFormDto>();
        result.LastName.ShouldBe("Rivera");
        result.FirstName.ShouldBe("Jaymon");
    }


    [Test]
    public async Task GetStudentByIdAsync_ShouldThrow_Exception_When_Student_Not_Found()
    {
        // Arrange
         _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllCommand<Student, StudentListDto>>(), default))
                .ReturnsAsync(Array.Empty<StudentListDto>());

        // Act & Assert
        var ex = await Should.ThrowAsync<Exception>(async () =>
            await _studentService.GetStudentByIdAsync(1)
        );
        ex.Message.ShouldBe("Student with Id: 1 cannot be found");
    }

    [Test]
    public async Task CreateStudentAsync_ShouldReturn_StudentId()
    {
        // Arrange
        var studentDto = new StudentFormDto
        {
            FirstName = "Jaymon",
            LastName = "Rivera",
            DateOfBirth = new DateTime(1996, 07, 18),
            Email = "jaymon@test.com",
            PhoneNumber = "09759623147"
        };
        _mediatorMock.Setup(m => m.Send(It.IsAny<CreateCommand<Student, StudentFormDto>>(), default))
                     .ReturnsAsync(1);

        // Act
        var result = await _studentService.CreateStudentAsync(studentDto);

        // Assert
        result.ShouldBe(1);
    }

    [Test]
    public async Task UpdateStudentAsync_ShouldReturn_UpdatedStudentId()
    {
        // Arrange
        var studentDto = new StudentFormDto
        {
            FirstName = "Jaymon",
            LastName = "Rivera",
            DateOfBirth = new DateTime(1996, 07, 18),
            Email = "jaymon@test.com",
            PhoneNumber = "09759623147"
        };

        _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateCommand<Student, StudentFormDto>>(), default))
                     .ReturnsAsync(1);

        // Act
        var result = await _studentService.UpdateStudentAsync(1, studentDto);

        // Assert
        result.ShouldBe(1);
    }

    [Test]
    public async Task DeleteStudentAsync_Should_CallMediatorSendOnce()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteCommand<Student>>(), default))
                     .Verifiable();

        // Act
        await _studentService.DeleteStudentAsync(1);

        // Assert
        _mediatorMock.Verify(m => m.Send(It.IsAny<DeleteCommand<Student>>(), default), Times.Once);
    }
}