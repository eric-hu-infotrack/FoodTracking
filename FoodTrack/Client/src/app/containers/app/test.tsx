import * as React from 'react';
import { MessageOutlined } from '@ant-design/icons';

export interface ITestProps {
}

export default class Test extends React.Component<ITestProps> {
  public render() {
    return (
      <div>
        <MessageOutlined style={{ fontSize: '16px', color: '#08c' }} />
      </div>
    );
  }
}
