
using Xunit;
using Moq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DISC_PruebaTecnica.Controllers;
using DISC_PruebaTecnica.DTO.JWT;
using DISC_PruebaTecnica.Configuration;
using DISC_PruebaTecnica.UseCase.JWT;
using MediatR;
using DISC_PruebaTecnica.DTO.General;

public class JWTControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly JWTController _controller;

    public JWTControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new JWTController(_mediatorMock.Object);
    }

    [Fact]
    public async Task PostToken_Returns401_WhenPresenterContentHasError()
    {
        // Arrange
        var presenter = new GenericPresenter { Content = new SuccessResult(true) }; // Simula error en el contenido
        var usuarioDto = new usrJWTdto { usuario ="121212", password ="11212"};

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<PostTokenCommand>(), default))
            .Callback<PostTokenCommand, CancellationToken>((command, _) =>
            {
                command.OutPutPort.Handle(new SuccessResult(true)); // Simula el error en la autenticación
            })
            .ReturnsAsync(Unit.Value);

        // Act
        var result = await _controller.PostToken(usuarioDto) as ObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(401, result.StatusCode);
    }

    [Fact]
    public async Task PostToken_Returns200_WhenPresenterContentHasNoError()
    {
        // Arrange
        var presenter = new GenericPresenter { Content = new SuccessResult(false) }; // Simula éxito en el contenido
        var usuarioDto = new usrJWTdto { /* Rellena con datos de prueba necesarios */ };

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<PostTokenCommand>(), default))
            .Callback<PostTokenCommand, CancellationToken>((command, _) =>
            {
                command.OutPutPort.Handle(new SuccessResult(false)); // Simula autenticación correcta
            })
            .ReturnsAsync(Unit.Value);

        // Act
        var result = await _controller.PostToken(usuarioDto) as ObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
    }
}



  