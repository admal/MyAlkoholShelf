import { ViewBase } from 'app/core/viewBase';
import * as $ from "jquery";

export class RecipiesListView extends ViewBase 
{
    private toggleRow(rowId: string) {
        $('#' + rowId).toggle();
    }
}