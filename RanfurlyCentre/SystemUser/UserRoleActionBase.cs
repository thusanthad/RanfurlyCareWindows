using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RanfurlyCentre
{    
   public abstract class UserRoleActionBase
    {
        public abstract void SelectNodes();
        protected TreeView _treeView;

        public UserRoleActionBase(TreeView treeView)
        {
            _treeView = treeView;
            UnCheckAllNodes();
        }

        private void UnCheckAllNodes()
        {
            foreach (TreeNode node in _treeView.Nodes)
            {
                node.Checked = false;
                foreach (TreeNode node1 in node.Nodes)
                {
                    node1.Checked = false;
                }
            }
        }

    }
}
