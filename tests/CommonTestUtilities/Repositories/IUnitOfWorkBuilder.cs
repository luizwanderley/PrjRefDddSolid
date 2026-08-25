using Moq;
using PrjRefDddSolid.Domain.Repositories;

namespace CommonTestUtilities.Repositories;

public class IUnitOfWorkBuilder
{
    public static IUnitOfWork Build()
    {
        var mock = new Mock<IUnitOfWork>();
        //mock.Setup(x => x.Commit()).Returns(Task.CompletedTask);
        return mock.Object;
    }
}
