# inventory-managment
A basic .NET MVC web app for warehouse inventory management

Users can view, edit, update, and delete the followng models with the basic views availale in the web app:

Products: Products each have a unique SKU and a description.

Bins: Bins are warehouse segments. Bins can conatin Inventory entries. Each Bin has a unique name.

Inventory: An Inventory entry has a Bin and a Product. Each Bin and Product combination is unique, and
describes the Product located in that Bin. Each Inventory entry has a quantity (QTY). The quantity must be a positive integer.

Order: An Order entry represents a customer order. It contains a unique ID, a customer's name and address, and a date stamp.
It also contains one or more OrderLine entries, describing the Products ordered.

OrderLine: This is an owned entity bound to Order objects. These are viewed and managed by a user via the Order model.
Each OrderLine entry has a Product and a quantity (QTY). The quantity must be a positive integer.

The Database used for this project is a MS LocalSQL server. A copy of the DB is included in the repo.
