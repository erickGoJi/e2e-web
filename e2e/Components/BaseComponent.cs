using Microsoft.AspNetCore.Components;

namespace e2e.Components
{
    public class BaseComponent : ComponentBase, IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
    {
    }
}
