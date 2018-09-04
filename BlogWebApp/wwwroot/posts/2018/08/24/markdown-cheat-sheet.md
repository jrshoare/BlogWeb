---
title: Markdown Cheat Sheet
abstract: This is a quick reference and showcase for the Markdown syntax.
keywords: Markdown
categories: Markdown
postDate: 2018-08-24T16:52:15.0000000+01:00
---
# [Markdown][] Cheat Sheet

This is a quick reference and showcase. For complete information see the [original spec][markdown] and/or the [Github-Flavored Markdown][github-markdown] information page.

## Headers

	# H1
	## H2
	### H3
	#### H4
	##### H5
	###### H6

	For H1 and H2, an underline style can be used:

	Alt-H1
	======

	Alt-H2
	------

# H1
## H2
### H3
#### H4
##### H5
###### H6

For H1 and H2, an underline style can be used:

Alt-H1
======

Alt-H2
------

## Emphasis

	Emphasis, aka italics, with *asterisks* or _underscores_.

	Strong emphasis, aka bold, with **asterisks** or __underscores__.

	Combined emphasis with **asterisks and _underscores_**.

	Strikethrough uses two tildes. ~~Scratch this.~~

Emphasis, aka italics, with *asterisks* or _underscores_.

Strong emphasis, aka bold, with **asterisks** or __underscores__.

Combined emphasis with **asterisks and _underscores_**.

Strikethrough uses two tildes. ~~Scratch this.~~

## Lists

	1. First ordered list item
	2. Another item
	⋅⋅* Unordered sub-list. 
	1. Actual numbers don't matter, just that it's a number
	⋅⋅1. Ordered sub-list
	4. And another item.

	You can have properly indented paragraphs within list items. Notice the blank line above, and the leading tab or spaces (at least one).

	To have a line break without a paragraph, you will need to use two trailing spaces.⋅⋅
	Note that this line is separate, but within the same paragraph.⋅⋅
	(This is contrary to the typical GFM line break behaviour, where trailing spaces are not required.)

	* Unordered list can use asterisks
	- Or minuses
	+ Or pluses

1. First ordered list item
2. Another item
* Unordered sub-list. 
1. Actual numbers don't matter, just that it's a number
1. Ordered sub-list
4. And another item.

	You can have properly indented paragraphs within list items. Notice the blank line above, and the leading tab or spaces (at least one).

	To have a line break without a paragraph, you will need to use two trailing spaces.  
	Note that this line is separate, but within the same paragraph.  
	(This is contrary to the typical [GFM][github-markdown] line break behaviour, where trailing spaces are not required.)

* Unordered list can use asterisks
- Or minuses
+ Or pluses

## Links

There are two ways to create links:

	[I'm an inline-style link](https://www.google.com)

	[I'm an inline-style link with title](https://www.google.com "Google's Homepage")

	[I'm a reference-style link][Arbitrary case-insensitive reference text]

	[I'm a relative reference to a repository file](../blob/master/LICENSE)

	[You can use numbers for reference-style link definitions][1]

	Or leave it empty and use the [link text itself].

	URLs and URLs in angle brackets will automatically get turned into links. 
	http://www.example.com or <http://www.example.com> and sometimes 
	example.com (but not on Github, for example).

	Some text to show that the reference links can follow later.

	[arbitrary case-insensitive reference text]: https://www.mozilla.org
	[1]: http://slashdot.org
	[link text itself]: http://www.reddit.com

[I'm an inline-style link](https://www.google.com)

[I'm an inline-style link with title](https://www.google.com "Google's Homepage")

[I'm a reference-style link][Arbitrary case-insensitive reference text]

[I'm a relative reference to a repository file](../blob/master/LICENSE)

[You can use numbers for reference-style link definitions][1]

Or leave it empty and use the [link text itself].

URLs and URLs in angle brackets will automatically get turned into links. 
http://www.example.com or <http://www.example.com> and sometimes 
example.com (but not on Github, for example).

Some text to show that the reference links can follow later.

[arbitrary case-insensitive reference text]: https://www.mozilla.org
[1]: http://slashdot.org
[link text itself]: http://www.reddit.com

## Images

	Here's our logo (hover to see the title text):

	Inline-style: 
	![alt text](/images/logo.png "Logo")

	Reference-style: 
	![alt text][logo]

	[logo]: /images/logo.png "Logo"

Here's our logo (hover to see the title text):

Inline-style: 
![alt text](/images/logo.png "Logo")

Reference-style: 
![alt text][logo]

[logo]: /img/logo.png "Logo"

## Code and Syntax Highlighting

Code blocks are part of the Markdown spec but syntax highlighting isn't. However many renderers -- like Github -- support syntax highlighting.

	Inline `code` has `back-ticks around` it.

Inline `code` has `back-ticks around` it.

Blocks of code are either fenced by lines with three back-ticks ```, or are indented with four spaces. I recommend only using the fenced code blocks -- they're easier and only they support syntax highlighting.

	```javascript
	var s = "JavaScript syntax highlighting";
	alert(s);
	```
	
	```python
	s = "Python syntax highlighting"
	print s
	```
	
	```
	No language indicated, so no syntax highlighting. 
	But let's throw in a <b>tag</b>.
	```

```javascript
var s = "JavaScript syntax highlighting";
alert(s);
```
 
```python
s = "Python syntax highlighting"
print s
```
 
```
No language indicated, so no syntax highlighting. 
But let's throw in a <b>tag</b>.
```

## Tables

Tables aren't part of the core Markdown spec, but they are part of [GFM][github-markdown]. They are an easy way of adding tables to your email -- a task that would otherwise require copy-pasting from another application.

	Colons can be used to align columns.

	| Tables        | Are           | Cool  |
	| ------------- |:-------------:| -----:|
	| col 3 is      | right-aligned | $1600 |
	| col 2 is      | centered      |   $12 |
	| zebra stripes | are neat      |    $1 |

	There must be at least 3 dashes separating each header cell.
	The outer pipes (|) are optional, and you don't need to make the 
	raw Markdown line up prettily. You can also use inline Markdown.

	Markdown | Less | Pretty
	--- | --- | ---
	*Still* | `renders` | **nicely**
	1 | 2 | 3

Colons can be used to align columns.

| Tables        | Are           | Cool  |
| ------------- |:-------------:| -----:|
| col 3 is      | right-aligned | $1600 |
| col 2 is      | centered      |   $12 |
| zebra stripes | are neat      |    $1 |

There must be at least 3 dashes separating each header cell.
The outer pipes (|) are optional, and you don't need to make the 
raw Markdown line up prettily. You can also use inline Markdown.

Markdown | Less | Pretty
--- | --- | ---
*Still* | `renders` | **nicely**
1 | 2 | 3

## Blockquotes

	> Blockquotes are very handy in email to emulate reply text.
	> This line is part of the same quote.

	Quote break.

	> This is a very long line that will still be quoted properly when it wraps. Oh boy let's keep writing to make sure this is long enough to actually wrap for everyone. Oh, you can *put* **Markdown** into a blockquote. 

> Blockquotes are very handy in email to emulate reply text.
> This line is part of the same quote.

Quote break.

> This is a very long line that will still be quoted properly when it wraps. Oh boy let's keep writing to make sure this is long enough to actually wrap for everyone. Oh, you can *put* **Markdown** into a blockquote. 

## Inline HTML

You can also use raw HTML in your Markdown, and it'll mostly work pretty well.

	<dl>
	<dt>Definition list</dt>
	<dd>Is something people use sometimes.</dd>

	<dt>Markdown in HTML</dt>
	<dd>Does *not* work **very** well. Use HTML <em>tags</em>.</dd>
	</dl>

Definition list
Is something people use sometimes.
Markdown in HTML
Does *not* work **very** well. Use HTML tags.

## Horizontal Rule

	Three or more...

	---

	Hyphens

	***

	Asterisks

	___

	Underscores

Three or more...

---

Hyphens

***

Asterisks

___

Underscores

## Line Breaks

My basic recommendation for learning how line breaks work is to experiment and discover -- hit <Enter> once (i.e., insert one newline), then hit it twice (i.e., insert two newlines), see what happens. You'll soon learn to get what you want.

Here are some things to try out:

	Here's a line for us to start with.

	This line is separated from the one above by two newlines, so it will be a *separate paragraph*.

	This line is also a separate paragraph, but...⋅⋅
	This line is separated by a single newline and the previous line ends with two spaces, so it's a separate line in the *same paragraph*.

Here's a line for us to start with.

This line is separated from the one above by two newlines, so it will be a *separate paragraph*.

This line is also a separate paragraph, but...  
This line is separated by a single newline and the previous line ends with two spaces, so it's a separate line in the *same paragraph*.
<br/>
<br/>
<br/>

[markdown]: http://daringfireball.net/projects/markdown/syntax
[github-markdown]: https://help.github.com/categories/writing-on-github/
