export class CompanyHolidayModel {
    constructor(
        public id: number,
        public employeeId: number,
        public approved: boolean,
        public startDate: Date,
        public endDate: Date,
    ) { }

    static fromJSON(object: any): CompanyHolidayModel {
        return new CompanyHolidayModel(
            object["id"],
            object["employeeId"],
            object["approved"],
            object["startDate"],
            object["endDate"]
        );
    }
    static fromJSONArray(array: Array<Object>): CompanyHolidayModel[] {
        return array.map(obj => CompanyHolidayModel.fromJSON(obj));
    }
}