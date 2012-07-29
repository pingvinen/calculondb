
namespace csharp CalculonDb


/**
 * Stream entry
 */
struct Entry {
	1: string guid
	2: string type
	3: map<string, string> data
}





/**
 * A report
 */
struct Report {
	1: string name
}




/**
 * Result object returned by
 * interface node methods
 */
struct Result {
	1: i32 statusCode
	2: i32 statusMessage
	3: list<Report> reports
}
