import * as $ from "jquery";

export abstract class HttpRequestData {
    public method: string;
    public params: any;
    public url: string;
    public headers: any;

    protected constructor(method: string) {
        this.method = method;
        this.headers = {
            'content-type': 'application/json',
            'accept': 'application/json'
        }
    }

    protected urlSetter(url: string): void {
        this.url = url;
    }
    protected urlGetter(): string {
        return this.url;
    }


    public abstract setUrl(url: string): void;
    public abstract setParams(params: any): void;
}

export class PostHttpRequestData extends HttpRequestData {
    setUrl(url: string): void {
        super.urlSetter(url);
    }

    setParams(params: any): void {
        this.body = JSON.stringify(params);
        console.log(this.body);

    }

    constructor() {
        super("POST");
    }

    public body: any;
}

export class GetHttpRequestData extends HttpRequestData {
    setUrl(url: string): void {
        super.urlSetter(url);
    }

    setParams(params: any): void {
        super.urlSetter(super.urlGetter() + "?" + $.param(params));
    }

    constructor() {
        super("GET");
    }

}