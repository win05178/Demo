using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Demo
{
  public class DeviceGroupFacts
  {
    public class GeneralUsage
    {
      [Fact]
      public void NewDeviceGroup_ShouldBeEmpty()
      {
        var g1 = new DeviceGroup();
       
        Assert.Equal(0, g1.Children.Count);
      }
     
    }
    public class TheUnitsPerMonthProperty
    {
      private readonly ITestOutputHelper output;
      public TheUnitsPerMonthProperty(ITestOutputHelper output)
      {
        this.output = output;
      }
      [Fact]
      public void OneDeviceInTheGroup()
      {
        var g = new DeviceGroup();
        var d = new DeviceItem();


        d.Name = "Notebook";
        d.Watts = 65;
        d.HoursPerDay = 10;
        d.DaysPerMonth = 20;

        listItem(g);

        g.Children.Add(d);
       
        Assert.Equal(13.0, g.UnitsPerMonth);

      }
      [Fact]
      public void AllowToAddSameObjectMutipleTimesInTherGroup()
      {
        var g = new DeviceGroup();
        var d = new DeviceItem();


        d.Name = "Notebook";
        d.Watts = 65;
        d.HoursPerDay = 10;
        d.DaysPerMonth = 20;


        g.Children.Add(d);


        g.Children.Add(d);
        listItem(g);
        Assert.Equal(26.0, g.UnitsPerMonth);

      }

      private void listItem(DeviceGroup g)
      {

        foreach (var d in g.Children.OfType<DeviceItem>())
        {
          output.WriteLine("{0} {1} watts x {2} hours = {3} units", d.Name, d.Watts, d.HoursPerDay, d.UnitsPerMonth);
        }

      }
    }

  }
}
