import * as React from 'react';
import { Row, Card, Col } from 'antd';
import { Item } from '../../stores/dashboardStore';

export interface IItemDetail {
    item: Item
}

export default class ItemDetail extends React.Component<IItemDetail> {
    public render() {
        console.log('rendering');
        return (
            <Card className="itemDetail">
                <Row>
                    <img
                        alt="example"
                        src={this.props.item.imageUrl}
                    />
                </Row>
                <Row>
                    <h1>{this.props.item.name}</h1>
                </Row>
                <Row>
                    <Col> +</Col>
                    <Col> {this.props.item.inputNumber}</Col>
                    <Col> -</Col>
                </Row>
                <Row>
                    <Col> {this.props.item.expectedNumber}</Col>
                    <Col> {this.props.item.expectedNumber - this.props.item.inputNumber}</Col>
                </Row>
            </Card>
        );
    }
}
