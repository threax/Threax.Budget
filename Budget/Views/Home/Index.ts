import * as standardCrudPage from 'htmlrapier.widgets/src/StandardCrudPage';
import * as startup from 'Client/Libs/startup';
import * as deepLink from 'htmlrapier/src/deeplink';
import { EntryCrudInjector } from 'Client/Libs/EntryCrudInjector';

import { CrudTableControllerExtensions } from 'htmlrapier.widgets/src/CrudTableController';
import * as client from 'Client/Libs/ServiceClient';
import * as controller from 'htmlrapier/src/controller';

class BudgetTableExtensions extends CrudTableControllerExtensions {
    private totalView: controller.IView<client.EntryCollection>;

    public setupBindings(bindings: controller.BindingCollection): void {
        this.totalView = bindings.getView("total");
    }

    public async loadExternalData(pageData: client.EntryCollectionResult): Promise<any> {
        this.totalView.setData(pageData.data);
        return Promise.resolve(null);
    }
}

var injector = EntryCrudInjector;

var builder = startup.createBuilder();
builder.Services.addTransient(CrudTableControllerExtensions, s => new BudgetTableExtensions());
deepLink.addServices(builder.Services);
standardCrudPage.addServices(builder, injector);
standardCrudPage.createControllers(builder, new standardCrudPage.Settings());