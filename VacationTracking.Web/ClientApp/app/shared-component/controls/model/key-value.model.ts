export class KeyValueModel {
    constructor(
        public key: string,
        public value: string
    ) { }

    static fromJSON(object: any): KeyValueModel {
        return new KeyValueModel(
            object["key"],
            object["value"]
        );
    }

    static fromJSONArray(array: Array<Object>): KeyValueModel[] {
        return array.map(obj =>
            KeyValueModel.fromJSON(obj)
        );
    }
}
