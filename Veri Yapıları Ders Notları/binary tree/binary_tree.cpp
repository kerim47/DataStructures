//binary tree
//basit bir yapidir
//bir node en fazla iki alt node alabilir

//7 elemanli bir tree graph olusturulacaktir.

#include <stdio.h>
#include <stdlib.h>

struct node
{
	int data;
	//sag ve sol veriler
	struct node *left;
	struct node *right;
};

//yeni bir alan ac ve node olustur
struct node *newNode(int data)
{
	struct node *neww = (struct node *)malloc(sizeof(struct node));
	neww->data = data;
	neww->left = NULL;
	neww->right = NULL;
	
	return neww;
}


int main()
{
	//root olustur
	struct node *root = newNode(1);
	
	//yeni bir node olustur ve root'a bagla
	root->left = newNode(2);
	root->right = newNode(3);
	
	//root'a bagli nodelarain altina node baglama
	root->left->left = newNode(4);
	root->left->right = newNode(5);
	root->right->left = newNode(6);
	root->right->right = newNode(7);
	
	printf("Root : %d \n", root->data);
	printf("Root left : %d \n",root->left->data);
	printf("Root right : %d \n",root->right->data);
	printf("Root left left : %d \n",root->left->left->data);
	printf("Root left right : %d \n",root->left->right->data);
	printf("Root right left : %d \n",root->right->left->data);
	printf("Root right right : %d \n",root->right->right->data);
	
	return 1;
}
