using System;
using System.Collections.Generic;
using System.Text;

namespace CRM_MODEL_LIB
{
    public class FakeBidRepository //: IBidRepository
    {
        public IEnumerable<Bid> Bids => new List<Bid>
        {
            new Bid {id = 1, name="KIRUHA PETROV",email="ewf@yandex.ru", content="dscsdcsdcsd4545t5",create_date= DateTime.Now },
            new Bid {id = 1, name="VASYA VANOV",email="d3ewf@yandex.ru", content="wevt5", create_date= DateTime.Now },
            new Bid {id = 1, name="KESHA POPOV",email="eefv@yandex.ru", content="wefwe5", create_date= DateTime.Now }
        };
    }
}
