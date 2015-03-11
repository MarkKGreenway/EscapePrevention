Escape Prevention
=============

This library is to strip out any characters that would have to be escaped later:

Kinds
-------

The following markups are supported.  The dependencies listed are required if
you wish to run the library. You can also run `script/bootstrap` to fetch them all.

* URL
* XML `(to be created)`
*

Usage
-----

    require 'github/markup'
    GitHub::Markup.render('README.markdown', "* One\n* Two")

Or, more realistically:

    require 'github/markup'
    GitHub::Markup.render(file, File.read(file))

Contributing
------------

See [Contributing](CONTRIBUTING.md)