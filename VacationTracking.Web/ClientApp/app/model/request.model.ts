export class RequestModel {
    constructor(
        public id: number,
        public employeeId: number,
        public name: string,
        public approved: boolean,
        public startDate: Date,
        public endDate: Date,
    ) { }

    static fromJSON(object: any): RequestModel {
        return new RequestModel(
            object["id"],
            object["employeeId"],
            object["name"],
            object["approved"],
            object["startDate"],
            object["endDate"]
        );
    }
    static fromJSONArray(array: Array<Object>): RequestModel[] {
        return array.map(obj => RequestModel.fromJSON(obj));
    }
}