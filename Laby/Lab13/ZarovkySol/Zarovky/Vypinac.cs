using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zarovky;

class Vypinac
{
    public event Action AkcePriKliknuti;

    public void Prepnuti()
    {
        AkcePriKliknuti?.Invoke();
    }
}