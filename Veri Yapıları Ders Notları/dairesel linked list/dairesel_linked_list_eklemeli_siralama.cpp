//dairesel yonlu bagli liste
//doubly list

#include <stdio.h>
#include <stdlib.h>

struct n{
	int x;
	n *next;
};

typedef n node;

void bastir(node *r)
{
	while(r!=NULL)
	{
		printf("%d - ",r->x);
		r = r->next;
	}
	printf("\n");
}

void ekle(node *r, int x)
{
	while(r->next!=NULL)
	{
		r = r->next;
	}
	r->next = (node *)malloc(sizeof(node));
	r->next->x = x;
	r->next->next = NULL;
}

node *ekleSirali(node *r, int x)
{
	if(r==NULL)
	{
		//liste bos ise
		r = (node *)malloc(sizeof(node));
		r->next = NULL;
		r->x = x;
		return r;
	}
	
	if(r->x > x)
	{
		//ilk elemandan kucuk olma durumu
		//rooot degisiyor
		node *temp = (node *)malloc(sizeof(node));
		temp->x = x;
		temp->next = r;
		return temp;
	}
	
	node *iter = r;
	while(iter->next!=NULL && iter->next->x < x)
	{
		iter = iter->next;
	}
	node *temp = (node *)malloc(sizeof(node));
	temp->next = iter->next;
	iter->next = temp;
	temp->x = x;
	return r;
}

node *sil(node *r, int x)
{
	node *temp;
	node *iter = r;
	if(r->x = x)
	{
		temp= r;
		r=r->next;
		free(temp);
		return r;
	}
	while(iter->next!=NULL && iter->next->x != x)
	{
		iter = iter->next;
	}
	if(iter->next == NULL)
	{
		printf("sayi bulunamadi");
		return r;
	}
	temp = iter->next;
	iter->next = iter->next->next;
	free(temp);
	return r;
}

//eklemeli siralama
node* createNode(int data) {
    node* newNode = (node*)malloc(sizeof(node));
    newNode->data = data;
    newNode->next = NULL;
    newNode->prev = NULL;

    return newNode;
}

node* insertSorted(node* root, int data) {
    node* newNode = createNode(data);

    if (root == NULL) {
        newNode->next = newNode;
        newNode->prev = newNode;
        return newNode;
    }

    node* iter = root;

    if (data <= iter->data) {
        newNode->next = iter;
        newNode->prev = iter->prev;

        iter->prev->next = newNode;
        iter->prev = newNode;

        return newNode;
    }

    while (iter->next != root && data > iter->next->data) {
        iter = iter->next;
    }

    newNode->next = iter->next;
    newNode->prev = iter;

    iter->next->prev = newNode;
    iter->next = newNode;

    return root;
}

node* insertionSort(node* root) {
    if (root == NULL || root->next == root) {
        return root;
    }

    node* sorted = NULL;
    node* iter = root;

    do {
        sorted = insertSorted(sorted, iter->data);
        iter = iter->next;
    } while (iter != root);

    return sorted;
}


int main()
{
	node * root;
	root = NULL;
	root = ekleSirali(root,400);
	root = ekleSirali(root,40);
	root = ekleSirali(root,4);
	root = ekleSirali(root,450);
	root = ekleSirali(root,50);
	bastir(root);
	
	//eklemeli siralama
	node* sorted = insertionSort(root);
    bastir(sorted);


	
}
