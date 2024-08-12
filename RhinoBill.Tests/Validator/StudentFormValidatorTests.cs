using FluentValidation.TestHelper;
using RhinoBill.CRUD.Controllers.Students.Dtos;

namespace RhinoBill.Tests.Validator;

[TestFixture]
public class StudentFormValidatorTests
{
    private StudentFormValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new StudentFormValidator();
    }

    [Test]
    public void Should_Have_Error_When_FirstName_Is_Empty()
    {
        var model = new StudentFormDto { FirstName = "" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.FirstName);
    }

    [Test]
    public void Should_Have_Error_When_FirstName_Is_Too_Short()
    {
        var model = new StudentFormDto { FirstName = "A" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.FirstName);
    }

    [Test]
    public void Should_Have_Error_When_FirstName_Contains_Invalid_Characters()
    {
        var model = new StudentFormDto { FirstName = "Jaymon123" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.FirstName);
    }

    [Test]
    public void Should_Not_Have_Error_When_FirstName_Is_Valid()
    {
        var model = new StudentFormDto { FirstName = "Jaymon" };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.FirstName);
    }

    [Test]
    public void Should_Have_Error_When_Email_Is_Invalid()
    {
        var model = new StudentFormDto { Email = "invalid-email" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Email);
    }

    [Test]
    public void Should_Not_Have_Error_When_Email_Is_Empty()
    {
        var model = new StudentFormDto { Email = "" };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.Email);
    }

    [Test]
    public void Should_Not_Have_Error_When_Email_Is_Valid()
    {
        var model = new StudentFormDto { Email = "jaymon.rivera@test.com" };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.Email);
    }

}