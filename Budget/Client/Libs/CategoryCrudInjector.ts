import * as client from 'clientlibs.ServiceClient';
import * as hyperCrud from 'hr.widgets.HypermediaCrudService';
import * as di from 'hr.di';

export class CategoryCrudInjector extends hyperCrud.AbstractHypermediaPageInjector {
    public static get InjectorArgs(): di.DiFunction<any>[] {
        return [client.EntryPointInjector];
    }

    constructor(private injector: client.EntryPointInjector) {
        super();
    }

    async list(query: any): Promise<hyperCrud.HypermediaCrudCollection> {
        var entry = await this.injector.load();
        return entry.listCategorys(query);
    }

    async canList(): Promise<boolean> {
        var entry = await this.injector.load();
        return entry.canListCategorys();
    }

    public getDeletePrompt(item: client.CategoryResult): string {
        return "Are you sure you want to delete the category?";
    }

    public getItemId(item: client.CategoryResult): string | null {
        return String(item.data.categoryId);
    }

    public createIdQuery(id: string): client.CategoryQuery | null {
        return {
            categoryId: id
        };
    }
}