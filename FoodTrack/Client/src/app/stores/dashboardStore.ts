import { observable } from 'mobx';
export class DashboardStore {
    @observable shopLists: ShopList[];

    constructor(shopLists: ShopList[]) {
        this.shopLists = [];
        shopLists.forEach(e => {
            this.shopLists.push(e);
        });
    }
}

export class ShopList {
    id: number;
    name: string;
    status: shopListStatus;
    items: Item[];

    constructor(id: number, name: string, status: shopListStatus) {
        this.id = id;
        this.name = name;
        this.status = status;
        this.items = [];
        this.items.push(new Item('bread', 'https://cdn0.woolworths.media/content/wowproductimages/large/095872.jpg', 2))
    }
}

export enum shopListStatus {
    ordered,
    notOrdered
}

export class Item {
    name: string;
    expectedNumber: number;
    inputNumber: number;
    imageUrl: string;

    constructor(name: string, imageUrl: string, expectedNumber: number) {
        this.name = name;
        this.expectedNumber = expectedNumber;
        this.imageUrl = imageUrl;
    }
}