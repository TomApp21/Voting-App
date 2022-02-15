using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VotingLibrary;

namespace Voting_App
{
    public partial class ViewElVoters : Form
    {
        public ViewElVoters(User loggedInUser)
        {
            InitializeComponent();
        }
    }
}
