import * as React from 'react';
import { Card } from 'antd';
import { ShopList } from 'app/stores/dashboardStore';

export interface IShopListProps {
    shopList: ShopList;
}

export default class ShopListCard extends React.Component<IShopListProps> {
    public render() {
        return (
            <Card hoverable={true} className="dashboardCard">
                <h1>{this.props.shopList.name}</h1>
            </Card>
        );
    }
}
