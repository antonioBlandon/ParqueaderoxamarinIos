using Foundation;
using ParqueaderoXamarinIos.Data;
using System;
using System.Collections.Generic;
using UIKit;

namespace ParqueaderoXamarinIos
{
    public partial class ParqueaderoController : UITableViewController
    {

        public List<Vehiculo> listVehiculo { get; set; }
        public ParqueaderoController (IntPtr handle) : base (handle)
        {
            listVehiculo = new List<Vehiculo>();
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return listVehiculo.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("itemVehiculo") as VehicleTableViewCell;
            Vehiculo vehiculo = listVehiculo[indexPath.Row];
            cell.VehiculoData = vehiculo;
            return cell;
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "DetailsSegue") {
                var navigationController = segue.DestinationViewController as DetailsController;
                if (navigationController != null) {
                    var rowPath = TableView.IndexPathForSelectedRow;
                    var selectedData = listVehiculo[rowPath.Row];
                    navigationController.placa = selectedData.getPlaca();
                }
            }
        }
    }
}