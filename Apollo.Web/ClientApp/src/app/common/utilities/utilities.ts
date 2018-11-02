export  class Utilities {
  static isNullOrEmpty = function(value: any): boolean {
    return value === undefined || value === null || value.toString().trim() === '';
  };
}
