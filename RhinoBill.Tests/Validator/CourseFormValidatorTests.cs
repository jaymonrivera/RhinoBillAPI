using FluentValidation.TestHelper;
using RhinoBill.CRUD.Controllers.Courses.Dtos;

namespace RhinoBill.Tests.Validator;

[TestFixture]
public class CourseFormValidatorTests
{
    private CourseFormValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new CourseFormValidator();
    }

    // Tests for Code
    [Test]
    public void Should_Have_Error_When_Code_Is_Empty()
    {
        var model = new CourseFormDto { Code = "" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Code);
    }

    [Test]
    public void Should_Have_Error_When_Code_Is_Too_Short()
    {
        var model = new CourseFormDto { Code = "1234" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Code);
    }

    [Test]
    public void Should_Have_Error_When_Code_Is_Too_Long()
    {
        var model = new CourseFormDto { Code = "12345678901" }; // 11 characters
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Code);
    }

    [Test]
    public void Should_Have_Error_When_Code_Contains_Special_Characters()
    {
        var model = new CourseFormDto { Code = "1234@#" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Code);
    }

    [Test]
    public void Should_Not_Have_Error_When_Code_Is_Valid()
    {
        var model = new CourseFormDto { Code = "ABC123" };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.Code);
    }

    // Tests for Title
    [Test]
    public void Should_Have_Error_When_Title_Is_Empty()
    {
        var model = new CourseFormDto { Title = "" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Title);
    }

    [Test]
    public void Should_Have_Error_When_Title_Is_Too_Short()
    {
        var model = new CourseFormDto { Title = "A" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Title);
    }

    [Test]
    public void Should_Have_Error_When_Title_Is_Too_Long()
    {
        var model = new CourseFormDto { Title = new string('A', 31) }; // 31 characters
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Title);
    }

    [Test]
    public void Should_Not_Have_Error_When_Title_Is_Valid()
    {
        var model = new CourseFormDto { Title = "Valid Title" };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.Title);
    }

    // Tests for Credits
    [Test]
    public void Should_Have_Error_When_Credits_Are_Zero()
    {
        var model = new CourseFormDto { Credits = 0 };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Credits);
    }

    [Test]
    public void Should_Have_Error_When_Credits_Are_Negative()
    {
        var model = new CourseFormDto { Credits = -1 };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Credits);
    }

    [Test]
    public void Should_Not_Have_Error_When_Credits_Are_Positive()
    {
        var model = new CourseFormDto { Credits = 5 };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.Credits);
    }
}