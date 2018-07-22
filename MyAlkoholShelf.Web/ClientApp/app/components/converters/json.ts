export class JsonValueConverter  {
    toView(value : any) {
        return JSON.stringify(value, null, "\t");
    }
}
