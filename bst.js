class BSNode {
    // each node in a binary search tree contains a value, a pointer to the node to the left, and a pointer to the node to the right
    constructor(value){
        this.value = value;
        this.left = null;
        this.right = null;
    }
}


class BSTree {
    constructor(){
        this.root = null;
    }


    // write an algorithm that can determine whether or not a binary search tree is empty.
    isEmpty() {
        if(this.root == null){
            return true;
        }
        else{
            return false;
        }
    }

    AddSmall(value){
        if(this.root == null){
            var newnode = new BSNode(value);
            this.root = newnode;
            return this;
        }
        else{
            var temp = this.root;
            while(temp.left != null){
                temp = temp.left;
            }
            var newnode = new BSNode(value);
            temp.left = newnode;
            // console.log(this.root.left);
            return this;
        }
    }

    AddLarge(value){
        if(this.root == null){
            var newnode = new BSNode(value);
            this.root = newnode;
            return this;
        }
        else{
            var temp = this.root;
            while(temp.right != null){
                temp = temp.right;
            }
            var newnode = new BSNode(value);
            temp.right = newnode;
            // console.log(this.root.right);
            return this;
        }
    }


    // write an algorithm that will find the smallest number in a binary search tree
    min(currentnode = 0){
        if(currentnode == 0){
            currentnode = this.root;
        }
        else if(currentnode.left == null){
            return currentnode.value;
        }
        return this.min(currentnode.left);
    }

    // write an algorithm that will find the largest number in a binary search tree
    max(currentnode = 0){
        if(currentnode == 0){
            currentnode = this.root;
        }
        // else if(currentnode.right ==)
        else if(currentnode.right == null){
            return currentnode.value;
        }
        return this.max(currentnode.right);
    }

    height(node = 0, tree_height = 0){
        if(node == 0){
            node = this.root;
        }
        tree_height++;
        if(node.left != null){
            var left = this.height(node.left, tree_height);
        }
        if(node.right != null){
            var right = this.height(node.right, tree_height);
        }
        if(node.left == null && node.right == null){
            return tree_height;
        }

        if(left > right){
            return left;
        }
        else{
            return right;
        }
    }

    isbalanced(){
        var treeroot = this.root;
        var left = treeroot.left;
        var right = treeroot.right;
        left_height = height(left);
        right_height = height(right);
        if(Math.abs(left_height - right_height) <= 1){
            return true;
        }
        else{
            return false;
        }
    }
}

//hi cody

var temp = new BSTree;
temp.AddSmall(4).AddSmall(3).AddSmall(2).AddSmall(1);
temp.AddLarge(1).AddLarge(2).AddLarge(3).AddLarge(4);
// console.log(temp.isEmpty());
// console.log(temp.root.left);
console.log(temp.max());
