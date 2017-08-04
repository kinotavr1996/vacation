export class SelectListItem {
    constructor(
        public value: number,
        public text: string
    ) { }

    static fromJSON(object: any): SelectListItem {
        return new SelectListItem(
            +object["value"],
            object["text"]
        );
    }
    static fromJSONArray(array: Array<Object>): SelectListItem[] {
        return array.map(obj => SelectListItem.fromJSON(obj));
    }
}
