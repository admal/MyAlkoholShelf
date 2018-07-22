import { Component, Input, OnInit, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: "mas:data-source",
    template: ""
})


export class DataSourceComponent implements OnInit {
    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl;
        //        this.http = http;
    }

    private baseUrl: string;
    //    private http: Http;

    execute(): void {
        this.http.get(this.baseUrl + this.url).subscribe(
            result => {
                this.data = result.json();
                console.info(this.data);
            },
            error => console.error(error)
        );
    }

    ngOnInit(): void {
        if (this.autoLoad) {
            this.execute();
        }
    }

    @Input() public url: string;
    @Input() public params: object;
    @Input() public method: string = "POST";
    @Input() public autoLoad: boolean = false;

    public data: any;
}
