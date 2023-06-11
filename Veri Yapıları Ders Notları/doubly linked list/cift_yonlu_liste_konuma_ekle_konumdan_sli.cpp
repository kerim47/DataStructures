//cift yonlu bagli liste
//doubly list

#include <stdio.h>
#include <stdlib.h>

struct n{
	int x;
	n *next;
	n *prev;//
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
/*
void ekle(node *r, int x)
{
	while(r->next!=NULL)
	{
		r = r->next;
	}
	r->next (node *)malloc(sizeof(node));
	r->next->x = x;
	r->next->next = NULL;
}
*/
node *ekleSirali(node *r, int x)
{
	if(r==NULL)
	{
		//liste bos ise
		r = (node *)malloc(sizeof(node));
		r->next = NULL;
		r->prev = NULL;//
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
	temp->prev = iter;
	
	if(temp->next!=NULL)
		temp->next->prev = temp;
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
	if(iter->next!=NULL)//
		iter->next->prev = iter;//
	return r;
}


//ters goster
void tersGoster(node *r)
{
    if (r == NULL) {
        printf("Liste bos\n");
        return;
    }
	//ilk deger
	int ilk = r->x;
	
    // Son düðüme kadar ileriye doðru iterasyonla ilerle
    while (r->next != NULL) {
        r = r->next;
    }

    printf("Ters Gosterim: ");
    
    // Son düðümden baþlayarak geriye doðru ilerle ve verileri yazdýr
    while (r != NULL) {
        printf("%d - ", r->x);
        r = r->prev;
    }
    printf("%d",ilk);
    printf("\n");
}


//konumdan silme kodu
node* createNode(int data) {
	node* newNode = (node*)malloc(sizeof(node));
	if (newNode == NULL) {
		printf("Bellek hatasi!\n");
		exit(1);
	}
	newNode->x = data;
	newNode->prev = NULL;
	newNode->next = NULL;
	return newNode;
}

void insertAtPosition(node** head, int data, int position) {
	node* newNode = createNode(data);
	if (*head == NULL) {
		*head = newNode;
		return;
	}
	if (position == 1) {
		newNode->next = *head;
		(*head)->prev = newNode;
		*head = newNode;
		return;
	}
	node* current = *head;
	int count = 1;
	while (count < position - 1 && current->next != NULL) {
		current = current->next;
		count++;
	}
	if (count != position - 1) {
		printf("Belirtilen konum bulunamadi.\n");
		free(newNode);
		return;
	}
	newNode->prev = current;
	newNode->next = current->next;
	if (current->next != NULL) {
		current->next->prev = newNode;
	}
	current->next = newNode;
}

void deleteAtPosition(node** head, int position) {
	if (*head == NULL) {
		printf("Liste bos.\n");
		return;
	}
	if (position == 1) {
		node* temp = *head;
		*head = (*head)->next;
		if (*head != NULL) {
			(*head)->prev = NULL;
		}
		free(temp);
		return;
	}
	node* current = *head;
	int count = 1;
	while (count < position && current != NULL) {
		current = current->next;
		count++;
	}
	if (current == NULL) {
		printf("Belirtilen konum bulunamadi.\n");
		return;
	}
	current->prev->next = current->next;
	if (current->next != NULL) {
		current->next->prev = current->prev;
	}
	free(current);
}

void printList(node* head) {
	node* current = head;
	while (current != NULL) {
		printf("%d ", current->x);
		current = current->next;
	}
	printf("\n");
}


int main()
{
	node* head = NULL;

	insertAtPosition(&head, 10, 1); // 10
	insertAtPosition(&head, 20, 2); // 10 20
	insertAtPosition(&head, 30, 3); // 10 20 30
	insertAtPosition(&head, 40, 4); // 10 20 30 40
	insertAtPosition(&head, 50, 5); // 10 20 30 40 50

	printf("Liste: ");
	printList(head);

	deleteAtPosition(&head, 3); // 10 20 40 50
	deleteAtPosition(&head, 1); // 20 40 50
	deleteAtPosition(&head, 4); // 20 40 50

	printf("Liste: ");
	printList(head);

	
}
