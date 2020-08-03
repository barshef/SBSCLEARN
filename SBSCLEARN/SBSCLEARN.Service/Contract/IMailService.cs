using SBSCLEARN.Domain;
using System.Threading.Tasks;

namespace SBSCLEARN.Service.Contract
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);

    }
}
