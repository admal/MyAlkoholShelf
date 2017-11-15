import { bindable, inject } from "aurelia-framework";
import * as $ from "jquery";
import { PLATFORM } from "aurelia-pal";

@inject(Element)
export class ModalCustomElement {
    @bindable template: string;
    @bindable title: string;

    data: any;
    element: any;
    
    public modalTemplateModuleName: string;

    constructor(element: any) {
        this.element = element;
        this.modalTemplateModuleName = PLATFORM.moduleName("app/components/fetchdata/my-modal");
    }
    public open(data : any) {
        this.data = data;
        console.log('data', data);
        $(this.element).find('.modal').modal();
    }
}