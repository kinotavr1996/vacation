import { RequestModel } from './request.model';
export class RequestListModel {
    constructor(
        public filter: string,
        public column: string,
        public direction: string,
        public hasNextPage: boolean,
        public hasPrePage: boolean,
        public pageSize: number,
        public totalPage: number,
        public page: number,
        public requestModel: RequestModel[]
    ) { }

    static fromJSON(object: any): RequestListModel {
        return new RequestListModel(
            object["filter"],
            object["order"]["column"],
            object["order"]["direction"],
            object["hasNextPage"],
            object["hasPreviousPage"],
            object["pageSize"],
            object["totalPages"],
            object["page"],
            RequestModel.fromJSONArray(object["items"])
        );
    }
    static fromJSONArray(array: Array<Object>): RequestListModel[] {
        return array.map(obj => RequestListModel.fromJSON(obj));
    }
}
