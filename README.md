# DiskTree

This project solves directories tree task: it creates a formatted directories list from known directories paths.

Input: List<string>, where each string represents one of the known paths.
Each string is no longer than 80 symbols, doesn't have whitespaces,
doesn't repeat in List and consists of directories, split by '\'.

Output: a formatted directories tree, represented by List<string>.
Each name of a directory consists of whitespaces (as many as a directory is deep) and its name.
Subdirectories follows main directory in lexicographical order.
Top-level directories don’t have whitespaces in their names and are sorted in lexicographical order.