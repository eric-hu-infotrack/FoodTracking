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
    name: string;
    status: shopListStatus;

    constructor(name: string, status: shopListStatus) {
        this.name = name;
        this.status = status;
    }
}

export enum shopListStatus {
    ordered,
    notOrdered
}