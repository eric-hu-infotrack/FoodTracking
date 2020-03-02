import * as React from 'react';
import { Card, Button } from 'antd';
import { ShopList } from 'app/stores/dashboardStore';

export interface IShopListProps {
    shopList: ShopList;
}

export default class ShopListCard extends React.Component<IShopListProps> {
    public render() {
        return (
            <Card>
                {this.props.shopList.name}
                <Button type="primary">Primary</Button>
            </Card>
        );
    }
}
