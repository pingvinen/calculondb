CalculonDB
===================

A database containing reports as opposed to tables/documents/columns.

You can think of a report as a sort of document containing logic and data.

Inserts are performed by adding entries to a stream in the database. Each entry has a "type". Each report subscribes to specific types. When an entry is added to the stream, the reports subscribing to the entry's type are handed the entry so that they can aggregate themselves.

Be aware that this is *not* a generel purpose database.


Additional notes
-------------------

The data is persisted using MongoDB.

Communication is done using a Thrift API.


Motivation
-------------------

So why yet another database?

The main purpose is to make complex reports available real-time by aggregating the data in the reports during inserts, instead of generating reports in performance heavy computations.

The secondary purpose is to make the database related code in applications simpler, by letting the database handle the complex stuff.

