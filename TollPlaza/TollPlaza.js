class Entry
{
    constructor(num,category,amount)
    {
        this.num=num;
        this.category=category;
        this.amount=amount;
    }
}
class TollManager
{
    Entries=[];
    ob=[];
    getData()
    {
        if(localStorage.getItem("store")!=undefined)
        {
            this.Entries=JSON.parse(localStorage.getItem("store"));
        }
    }
    addNewEnrty=(ex)=>
    {
       this.getData();
       this.Entries.push(ex);
       localStorage.setItem("store",JSON.stringify(this.Entries));
    };
    getAllEntries=()=>{this.getData();return this.Entries}; 
    findEntryByCategory=(cat)=>
    {
        this.getData();
        return this.Entries.filter((e)=>e.category==cat);
        // alert(this.ob[0].num);
    }
    findEntryByRegistration=(reg)=>
    {
        this.getData();
        return this.Entries.filter((e)=>e.num==reg);
    }
}