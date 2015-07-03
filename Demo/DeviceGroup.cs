using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
  public class DeviceGroup:Device
  {
    public ICollection<Device> Children { get; set; }

    public DeviceGroup()
    {
      Children = new List<Device>();
    }


    public override double UnitsPerMonth
    {
      get {

        return this.Children.Sum(d => d.UnitsPerMonth);
      }
    }
  }
}
