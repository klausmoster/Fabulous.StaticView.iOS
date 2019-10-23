using System;
using Foundation;
using UIKit;

namespace MultiPageApp.iOS.ViewController
{
    public class PeopleTableViewDataSource : UITableViewDataSource
    {
        private readonly Common.Person[] _people;

        public PeopleTableViewDataSource(Common.Person[] people)
        {
            _people = people;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return _people?.Length ?? 0;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("PersonTableViewCell");
            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, "PersonTableViewCell")
                {
                    Accessory = UITableViewCellAccessory.DisclosureIndicator
                };
            }

            var person = _people[indexPath.Row];

            cell.TextLabel.Text = $"{person.Firstname} {person.Lastname}";
            return cell;
        }
    }
}
