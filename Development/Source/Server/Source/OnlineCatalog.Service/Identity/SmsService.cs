using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace OnlineCatalog.Service.Identity
{
    public class SmsService: IIdentityMessageService
    {
        #region IIdentityMessageService Members

        public Task SendAsync(IdentityMessage message)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
