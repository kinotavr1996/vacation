export class VacationPolicyModel {
    constructor(
        public id: number,
        public year: number,
        public days: number,
    ) { }

    static fromJSON(object: any): VacationPolicyModel {
        return new VacationPolicyModel(
            object["id"],
            object["year"],
            object["days"]
        );
    }
    static fromJSONArray(array: Array<Object>): VacationPolicyModel[] {
        return array.map(obj => VacationPolicyModel.fromJSON(obj));
    }
}