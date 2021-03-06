import request from '@/utils/request';
import PagingQueryViewModel from '@/@types/PagingQueryViewModel';

export async function query(params: PagingQueryViewModel): Promise<any> {
    return request('/api/v1.0/users', {
        method: 'get',
        params: params
    });
}

export async function create(model: any): Promise<any> {
    return request('/api/v1.0/users', {
        method: 'put',
        data: model
    });
}
