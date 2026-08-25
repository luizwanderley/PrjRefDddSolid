using Moq;
using PrjRefDddSolid.Domain.Repositories;
using PrjRefDddSolid.Domain.Repositories.User;

namespace CommonTestUtilities.Repositories;

public class IUserWriteOnlyRepositoryBuilder
{
    public static IUserWriteOnlyRepository Build()
    {
        var mock = new Mock<IUserWriteOnlyRepository>();
        //mock.Setup(x => x.Commit()).Returns(Task.CompletedTask);
        return mock.Object;
    }
}
