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

//seçmeli - selection siralama
void selectionSort(node *r)
{
    node *i, *j, *min;
    int temp;

    for (i = r; i != NULL; i = i->next)
    {
        min = i;
        for (j = i->next; j != NULL; j = j->next)
        {
            if (j->x < min->x)
            {
                min = j;
            }
        }
        if (min != i)
        {
            temp = i->x;
            i->x = min->x;
            min->x = temp;
        }
    }
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
	
    printf("Sýralanmýþ liste: ");
    selectionSort(root);
    bastir(root);


	
}
