export class CompanyHolidayModel {
    constructor(
        public id: number,
        public name: string,
        public Date: Date,
    ) { }

    static fromJSON(object: any): CompanyHolidayModel {
        return new CompanyHolidayModel(
            object["id"],
            object["name"],
            object["holidayDate"]
        );
    }
    static fromJSONArray(array: Array<Object>): CompanyHolidayModel[] {
        return array.map(obj => CompanyHolidayModel.fromJSON(obj));
    }
}