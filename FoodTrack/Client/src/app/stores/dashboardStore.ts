import { observable, action } from 'mobx';
export class DashboardStore {
    @observable shopLists: ShopList[];

    constructor(shopLists: ShopList[]) {
        this.shopLists = [];
        shopLists.forEach(e => {
            this.shopLists.push(e);
        });
    }

    @action
    async getdata() {
        let test = await fetch("https://localhost:44368/api/categories").then(res => res.json());
        console.log(test);
        test.items.map(e => {
            this.shopLists.push(new ShopList(e.id,e.name,shopListStatus.ordered));
          });
    }
}

export class ShopList {
    @observable id: number;
    @observable name: string;
    @observable status: shopListStatus;
    @observable items: Item[];

    constructor(id: number, name: string, status: shopListStatus) {
        this.id = id;
        this.name = name;
        this.status = status;
        this.items = [];
    }

    @action
    async getdata(id:number) {
        let test = await fetch("https://localhost:44368/api/categoryitems?categoryid="+id).then(res => res.json());
        console.log(test);
        test.items.map(e => {
            this.items.push(new Item(e.id,e.itemName,e.itemProfilePath, e.defaultQuantityNeeded));
          });
    }

    @action
    async save(){
        let request:item[] = this.items.map(e=> new item(e.inputNumber,e.expectedNumber,+e.id))
        let newrequest = {orderItemCreateRequests: request,categoryId:this.id};
        var xhr = new XMLHttpRequest();
        xhr.open('POST', 'https://localhost:44368/api/orders');
        xhr.setRequestHeader("Content-type", "application/json");
        xhr.send(JSON.stringify(newrequest));
    }
}

class item {
    availableQuantity:number;
    quantityNeeded:number;
    categoryItemId:number;

    constructor(a:number,n:number,id:number){
        this.availableQuantity = a;
        this.quantityNeeded = n;
        this.categoryItemId = id;
    }
}


export enum shopListStatus {
    ordered,
    notOrdered
}

export class Item {
    id:string;
    name: string;
    expectedNumber: number;
    @observable inputNumber: number;
    imageUrl: string;

    constructor(id:string,name: string, imageUrl: string, expectedNumber: number) {
        this.id = id;
        this.name = name;
        this.expectedNumber = expectedNumber;
        this.imageUrl = imageUrl;
        this.inputNumber = 0;
    }

    @action
    changeNumber(value: number) {
        value = value < 0 ? 0 : value;
        this.inputNumber = value;
    }
}