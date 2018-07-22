import * as moment from "moment";
import 'moment/locale/pl';

export class DateValueConverter {
    toView(value: string) {
        return moment(value).format("LL");
    }
}
    