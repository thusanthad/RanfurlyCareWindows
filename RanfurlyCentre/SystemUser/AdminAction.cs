using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RanfurlyCentre    
{
    public class AdminAction:UserRoleActionBase
    {

        public AdminAction(TreeView treeView):base(treeView)
        {

        }

        public override void SelectNodes()
        {
            CheckAllNodes();
        }

        private void CheckAllNodes()
        {
            foreach (TreeNode node in _treeView.Nodes)
            {
                node.Checked = true;
                foreach (TreeNode node1 in node.Nodes)
                {
                    node1.Checked = true;
                }
            }
        }

    }
}
