import React from 'react';
import { Card, Icon, Button } from 'antd';
import { RouteProps } from 'dva/router';
import { ConnectProps, ConnectState } from '../../models/connect';
import { router } from 'umi';
import { connect } from 'dva';
import EditTabs from '@/components/EditClientPanels/EditTabs';
import { formatMessage } from 'umi-plugin-locale';



export interface IEditClientProps extends RouteProps, ConnectProps {
    loading?: boolean;
    detail?: any;
    updating?: boolean;
}

class EditClient extends React.Component<IEditClientProps> {
    componentDidMount() {
        const { match, dispatch } = this.props;
        if (match) {
            const { id } = match.params;
            dispatch && dispatch({
                type: 'client/fetchDetail',
                payload: id
            })
        }
    }


    handleUpdate(values: any) {
        const { dispatch } = this.props;
        dispatch && dispatch({
            type: 'client/update',
            payload: values
        })
    }

    render() {
        const { updating, loading, detail = {} } = this.props;
        const { clientId } = detail;

        console.log(detail);

        return (
            <Card
                loading={loading}
                style={{ width: '100%', padding: '0px' }}>
                <h1>
                    <Button type="link" onClick={() => router.push('/clients')}><Icon type="left" /></Button>
                    {formatMessage({ id: 'app.shared.client', defaultMessage: "Client" })} : {clientId}
                </h1>
                <EditTabs detail={detail}
                    updating={updating}
                    onUpdate={this.handleUpdate.bind(this)} />
            </Card >
        )
    }
}

export default connect(({ client, loading }: ConnectState) => ({
    detail: client.detail,
    loading: loading.effects['client/fetchDetail'],
    updating: loading.effects['client/update'],
}))(EditClient)